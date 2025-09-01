using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using MCPServer2.Model;
using MCPServer2.ViewModel;
using Microsoft.Playwright;
using ModelContextProtocol.Server;

namespace MCPServer2.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        
        public ICommand RunButtonCommand { get; }

        public MainViewModel()
        {
            RunButtonCommand = new ViewModelCommand(ExecuteRunButtonCommand);
        }

        private async void ExecuteRunButtonCommand(object obj)
        {
            //MessageBox.Show("Run");
            string id = "sungjong.son";
            string pw = "1234";
            await loginMyCompany(id, pw);
        }

        private IPlaywright? m_play_wright;
        private IBrowser? m_browser;
        private IBrowserContext? m_context;
        private IPage? m_page;

        public async Task loginMyCompany(string id, string pw)
        {
            try
            {
                m_play_wright = await Playwright.CreateAsync();
                m_browser = await m_play_wright.Chromium.LaunchAsync(new()
                {
                    Channel = "msedge",         // 엣지 브라우저
                    Headless = false
                });

                m_context = await m_browser.NewContextAsync(new() { ViewportSize = null });
                m_page = await m_context.NewPageAsync();

                // 로그인 페이지로
                await m_page.GotoAsync("https://groupware.lig.kr/", new() { WaitUntil = WaitUntilState.NetworkIdle });

                // 3) 로그인 필요 여부 판단
                bool onLoginUrl = m_page.Url.Contains("/login", StringComparison.OrdinalIgnoreCase);
                bool hasLoginDom = await m_page.Locator("#username, #password, #login_submit, .btn_login").CountAsync() > 0;
                bool needLogin = onLoginUrl || hasLoginDom;

                if(needLogin)
                {
                    await m_page.Locator("#username").WaitForAsync(new() { Timeout = 10000 });
                    // 아이디 / 비밀번호 입력
                    await m_page.FillAsync("#username", id);
                    await m_page.FillAsync("#password", pw);

                    // 로그인 버튼 클릭
                    await m_page.ClickAsync("#login_submit, .btn_login");
                    // 로그인 완료 대기
                    await m_page.WaitForLoadStateAsync(LoadState.NetworkIdle);
                    //MessageBox.Show("자동 로그인 실행 완료");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"실패: {ex.Message}");
            }
        }
    }
}

