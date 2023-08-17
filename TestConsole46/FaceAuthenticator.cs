using MetsaKuur;

namespace TestConsole46
{
    public class FaceAuthenticator
    {
        private readonly int CaptureWaitingTime = 10000;
        private readonly string CameraName = "ABKO";
        private readonly string Channel = "ASI";

        private RequestInfo serverInfo;
        private string cachedtAuthCapturedData = string.Empty;
        private string cachedRegisterCapturedData = string.Empty;
        private string cachedPrepareAuthResultData = string.Empty;
        private bool isPasswordRegistration = false;
        private bool isFaceRegistration = false;

        public bool IsPasswordRegistration { get { return isPasswordRegistration; } }
        public bool IsFaceRegistration { get { return isFaceRegistration; } }

        public FaceAuthenticator(RequestInfo serverInfo)
        {
            this.serverInfo = serverInfo;
        }

        private void PrepareAuthentication(in string ssoId)
        {
            AuthListResponse authListResponse;
            PolicyApi policyApi = new PolicyApi(this.serverInfo);
            if (!policyApi.GetAuthenticationList(ApcBusinessDefinition.EeWinAgentId, ssoId, out authListResponse))
                throw new ServerApiException(ServerApiError.NetworkCommunicationFaild);

            if (authListResponse.resultCode != ResponseCodeDefinition.ApcSuccess)
            {
                string message = string.Empty;
                if (!string.IsNullOrEmpty(authListResponse.resultMessage))
                    message = authListResponse.resultMessage;

                throw new FaceAuthenticatorException(message);
            }

            this.cachedPrepareAuthResultData = authListResponse.apcToken;

            UserInfoResponse userInfoResponse;
            UserApi userApi = new UserApi(this.serverInfo);
            if (!userApi.GetUserInfo(ssoId, authListResponse.apcToken, out userInfoResponse))
                throw new ServerApiException(ServerApiError.NetworkCommunicationFaild);

            if (userInfoResponse.resultCode != ResponseCodeDefinition.ApcSuccess)
            {
                string message = string.Empty;
                if (!string.IsNullOrEmpty(userInfoResponse.resultMessage))
                    message = userInfoResponse.resultMessage;

                throw new FaceAuthenticatorException(message);
            }

            this.isFaceRegistration = userInfoResponse.registeredFace;
            this.isPasswordRegistration = userInfoResponse.pwValue;
        }

        public void Authenticate(in string ssoId, out string validUntilDate, out string secureToken, out string password)
        {
            if (string.IsNullOrEmpty(this.cachedtAuthCapturedData))
            {
                MKAuthenticator mkAuthenticator = new MKAuthenticator(this.CameraName);
                mkAuthenticator.TopMost = true;
                try
                {
                    if (!mkAuthenticator.IsCamOpened())
                        throw new FaceAuthenticatorException(FaceAuthError.InitDeviceFailed);

                    if (!mkAuthenticator.StartCapture(this.CaptureWaitingTime))
                        throw new FaceAuthenticatorException(FaceAuthError.StartCaptureFailed);

                    this.cachedtAuthCapturedData = mkAuthenticator.Authentication(ssoId, this.Channel, SysInfo.SysInfo.GetMacAddress());
                    if (string.IsNullOrEmpty(this.cachedtAuthCapturedData))
                        throw new FaceAuthenticatorException(FaceAuthError.CaptureFailed);
                }
                finally
                {
                    if (mkAuthenticator.IsCamOpened())
                        mkAuthenticator.ReleaseCam();
                }
            }

            FaceApi faceApi = new FaceApi(this.serverInfo);
            FaceAuthResponse faceAuthResponse;
            if (!faceApi.Authentication(new FaceAuthRequestDto() { userId = ssoId, data = this.cachedtAuthCapturedData },
                this.cachedPrepareAuthResultData, out faceAuthResponse))
                throw new ServerApiException(ServerApiError.NetworkCommunicationFaild);

            if (faceAuthResponse.resultCode != ResponseCodeDefinition.ApcSuccess)
            {
                string message = string.Empty;
                if (!string.IsNullOrEmpty(faceAuthResponse.resultMessage))
                    message = faceAuthResponse.resultMessage;


                if (!string.IsNullOrEmpty(faceAuthResponse.code))
                    message += string.Format("(에러코드 : {0})", faceAuthResponse.code);

                throw new FaceAuthenticatorException(message);
            }

            validUntilDate = faceAuthResponse.validUntilDate;
            secureToken = faceAuthResponse.secureToken;
            password = faceAuthResponse.password;
        }

        public void Register(in string ssoId, in string ssoPw)
        {
            if (string.IsNullOrEmpty(this.cachedRegisterCapturedData))
            {
                MKRegister mkRegister = new MKRegister(this.CameraName);
                mkRegister.TopMost = true;
                try
                {
                    if (!mkRegister.IsCamOpened())
                        throw new FaceAuthenticatorException(FaceAuthError.InitDeviceFailed);

                    if (!mkRegister.StartCapture(this.CaptureWaitingTime))
                        throw new FaceAuthenticatorException(FaceAuthError.StartCaptureFailed);

                    this.cachedRegisterCapturedData = mkRegister.Registration(ssoId, this.Channel, ssoPw, SysInfo.SysInfo.GetMacAddress());
                    if (string.IsNullOrEmpty(this.cachedRegisterCapturedData))
                        throw new FaceAuthenticatorException(FaceAuthError.CaptureFailed);
                }
                finally
                {
                    if (mkRegister.IsCamOpened())
                        mkRegister.ReleaseCam();
                }
            }

            if (string.IsNullOrEmpty(this.cachedPrepareAuthResultData))
                this.PrepareAuthentication(ssoId);

            FaceApi faceApi = new FaceApi(this.serverInfo);
            FaceRegisterResponse faceRegisterResponse;
            if (!faceApi.Register(new FaceRegisterRequestDto() { userId = ssoId, data = this.cachedRegisterCapturedData, password = ssoPw },
                this.cachedPrepareAuthResultData, out faceRegisterResponse))
                throw new ServerApiException(ServerApiError.NetworkCommunicationFaild);

            if (faceRegisterResponse.resultCode != ResponseCodeDefinition.ApcSuccess)
            {
                string message = string.Empty;
                if (!string.IsNullOrEmpty(faceRegisterResponse.resultMessage))
                    message = faceRegisterResponse.resultMessage;


                string detail = string.Empty;
                if (!string.IsNullOrEmpty(faceRegisterResponse.code))
                    message += string.Format("(에러코드 : {0})", faceRegisterResponse.code);

                throw new FaceAuthenticatorException(message);
            }

        }

        public bool CheckRegistered(in string ssoId)
        {
            if (string.IsNullOrEmpty(this.cachedtAuthCapturedData))
            {
                MKAuthenticator mkAuthenticator = new MKAuthenticator(this.CameraName);
                mkAuthenticator.TopMost = true;
                try
                {
                    if (!mkAuthenticator.IsCamOpened())
                        throw new FaceAuthenticatorException(FaceAuthError.InitDeviceFailed);

                    if (!mkAuthenticator.StartCapture(this.CaptureWaitingTime))
                        throw new FaceAuthenticatorException(FaceAuthError.StartCaptureFailed);

                    this.cachedtAuthCapturedData = mkAuthenticator.Authentication(ssoId, this.Channel, SysInfo.SysInfo.GetMacAddress());
                    if (string.IsNullOrEmpty(this.cachedtAuthCapturedData))
                        throw new FaceAuthenticatorException(FaceAuthError.CaptureFailed);
                }
                finally
                {
                    if (mkAuthenticator.IsCamOpened())
                        mkAuthenticator.ReleaseCam();
                }
            }

            if (string.IsNullOrEmpty(this.cachedPrepareAuthResultData))
                this.PrepareAuthentication(ssoId);

            FaceApi faceApi = new FaceApi(this.serverInfo);
            FaceGetStatusResponse faceGetStatusResponse;
            if (!faceApi.GetStatus(new FaceGetStatusRequestDto() { userId = ssoId, data = this.cachedtAuthCapturedData },
                this.cachedPrepareAuthResultData, out faceGetStatusResponse))
                throw new ServerApiException(ServerApiError.NetworkCommunicationFaild);

            if (faceGetStatusResponse.resultCode != ResponseCodeDefinition.ApcSuccess)
            {
                string message = string.Empty;
                if (!string.IsNullOrEmpty(faceGetStatusResponse.resultMessage))
                    message = faceGetStatusResponse.resultMessage;

                throw new FaceAuthenticatorException(message);
            }

            return faceGetStatusResponse.isRegistered;
        }

        public void MotpAuthentication(in string ssoId, in string otpNumber, out string encPassword)
        {
            MotpApi motpApi = new MotpApi(this.serverInfo);
            MotpAuthResponse motpAuthResponse = new MotpAuthResponse();

            // MTOP 인증
            MotpAuthRequestDto motpAuthenticationRequest = new MotpAuthRequestDto();
            motpAuthenticationRequest.userId = ssoId;
            motpAuthenticationRequest.otpNumber = otpNumber;

            // 결과 값 처리 필요
            if (!motpApi.Authentication(this.cachedPrepareAuthResultData, motpAuthenticationRequest, out motpAuthResponse))
            {
                throw new ServerApiException(ServerApiError.NetworkCommunicationFaild);
            }
            if (motpAuthResponse.resultCode != ResponseCodeDefinition.ApcSuccess)
            {
                string message = string.Empty;
                if (!string.IsNullOrEmpty(motpAuthResponse.resultMessage))
                    message = motpAuthResponse.resultMessage;

                throw new FaceAuthenticatorException(message);
            }
            if (string.IsNullOrEmpty(motpAuthResponse.password))
            {
                throw new ServerApiException(ServerApiError.InvalidResponseDataValue);
            }

            encPassword = motpAuthResponse.password;
        }

        public void ClearCachedData()
        {
            this.cachedtAuthCapturedData = string.Empty;
            this.cachedRegisterCapturedData = string.Empty;
            this.cachedPrepareAuthResultData = string.Empty;
        }
    }
}
