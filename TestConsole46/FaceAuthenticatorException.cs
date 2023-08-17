using System;

namespace Penta.EeWin.Cp.FaceCp.FaceAuth
{
    public enum FaceAuthError
    {
        InitDeviceFailed = -1,
        StartCaptureFailed = -2,
        CaptureFailed = -3,
    }
    public class FaceAuthenticatorException : Exception
    {
        public static readonly string DefaultExceptionMessage = "얼굴 인증에 실패하였습니다.";

        public FaceAuthenticatorException(string message) : base(ModifyMessage(message)) { }
        public FaceAuthenticatorException(FaceAuthError faceAuthError) : base(GetMessage(faceAuthError)) { }
        public FaceAuthenticatorException(FaceAuthError faceAuthError, string detail) : base(GetMessage(faceAuthError, detail)) { }

        private static string ModifyMessage(in string message)
        {
            if (string.IsNullOrEmpty(message))
                return DefaultExceptionMessage;

            return message;
        }

        private static string GetMessage(in FaceAuthError faceAuthError, in string detail = "")
        {
            string msg;
            switch (faceAuthError)
            {
                case FaceAuthError.InitDeviceFailed:
                    msg = "얼굴 인식 장치 초기화에 실패 하였습니다.";
                    break;                
                case FaceAuthError.CaptureFailed:
                    msg = "얼굴 캡처에 실패하였습니다.";
                    break;
                case FaceAuthError.StartCaptureFailed:
                default:
                    msg = DefaultExceptionMessage;
                    break;
            }
            return msg + " " + detail;
        }
    }
}
