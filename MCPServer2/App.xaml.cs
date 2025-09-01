// Nuget 콘솔에서 해당 프로젝트에 설치
// Install-Package ModelContextProtocol -Prerelease
// Install-Package ModelContextProtocol.AspNetCore -Prerelease

using MCPServer2.View;
using System.Configuration;
using System.Data;
using System.Windows;
using System.ComponentModel;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ModelContextProtocol.Server;
using ModelContextProtocol.AspNetCore;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.Xml;
using Microsoft.Playwright;

namespace MCPServer2
{
    public partial class App : Application
    {
        private IHost? m_mcpHost;


        // App.xaml 에서 StartupUri 를 Startup 으로 바꾸고 Startup="ApplicationStart" 로 바꿀 것
        private void ApplicationStart(object sender, StartupEventArgs e)
        {
            runMCPServer();
            
            var mainView = new MainView();
            mainView.Show();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            m_mcpHost?.Dispose();

            base.OnExit(e);
        }

        void runMCPServer()
        {
            // 1) Kestrel 직접 구성: 포트/주소 고정
            var builder = WebApplication.CreateBuilder();
            builder.WebHost.UseUrls("http://127.0.0.1:5000");   // 필요시 0.0.0.0로

            // 2) MCP 서버 + HTTP 전송 + 툴 등록
            builder.Services.AddMcpServer().WithHttpTransport().WithToolsFromAssembly();

            var app = builder.Build();

            // 3) MCP 엔드포인트 경로 명시
            app.MapMcp("/mcp");             // http://127.0.0.1:5000/mcp

            // 4) 서버 시작
            app.Start();

            m_mcpHost = app;
        }
    }
}


[McpServerToolType]
public static class UiTools
{
    [McpServerTool, Description("WPF에서 알림창을 띄웁니다.")]
    public static string show_message(string message)               // 대문자로 작성해도 소문자로 파이썬에 전달된다
    {
        MessageBox.Show(message, "MCP Toast");
        return "C#에서 완료해서 리턴했다";
    }
}

[McpServerToolType]
public static class MyTools
{
    // 내부에서만 쓰는 Playwright 실행 로직 (static)
    private static async Task RunLoginAsync(string id, string pw)
    {
        try
        {
            var pwrt = await Playwright.CreateAsync();
            var browser = await pwrt.Chromium.LaunchAsync(new()
            {
                Channel = "msedge",   // Edge 브라우저
                Headless = false
            });

            var context = await browser.NewContextAsync(new() { ViewportSize = null });
            var page = await context.NewPageAsync();

            await page.GotoAsync("https://groupware.lig.kr/", new() { WaitUntil = WaitUntilState.NetworkIdle });

            bool onLoginUrl = page.Url.Contains("/login", StringComparison.OrdinalIgnoreCase);
            bool hasLoginDom = await page.Locator("#username, #password, #login_submit, .btn_login").CountAsync() > 0;
            bool needLogin = onLoginUrl || hasLoginDom;

            if (needLogin)
            {
                await page.Locator("#username").WaitForAsync(new() { Timeout = 10000 });
                await page.FillAsync("#username", id);
                await page.FillAsync("#password", pw);
                await page.ClickAsync("#login_submit, .btn_login");
                await page.WaitForLoadStateAsync(LoadState.NetworkIdle);
            }
        }
        catch (Exception ex)
        {
            // MCP 툴은 보통 MessageBox 안 띄우고 string 반환하는 게 낫습니다.
            throw new Exception($"로그인 실패: {ex.Message}", ex);
        }
    }

    [McpServerTool, Description("에이전트에서 그룹웨어 로그인을 실행합니다")]
    public static async Task<string> login_company(string id, string pw)
    {
        await RunLoginAsync(id, pw);
        return "로그인 시도 완료";
    }
}


/*

# pip install "mcp[cli]"

import asyncio
from mcp.client.session import ClientSession
from mcp.client.streamable_http import streamablehttp_client

MCP_URL = "http://127.0.0.1:5000/mcp"

async def main():
    # 서버와 스트림 연결
    async with streamablehttp_client(MCP_URL) as (read_stream, write_stream, _):
        # 세션 생성 및 초기화
        async with ClientSession(read_stream, write_stream) as session:
            await session.initialize()

            # 툴 목록 확인
            tools = await session.list_tools()
            print("TOOLS:", [t.name for t in tools.tools])

            # 툴 호출 (C#에서 함수 이름으로 변경)
            result = await session.call_tool("login_company", {"id": "sungjong.son", "pw":"lig@1010719!"})
            for c in result.content:
                if c.type == "text":
                    print("RESULT:", c.text)

if __name__ == "__main__":
    asyncio.run(main()) 
 
 
*/