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
public static class RpaTools
{
    public record LoginArgs(string username, string password);

    [McpServerTool(Name = "login_groupware"), Description("LIG 그룹웨어 로그인")]
    public static async Task<string> LoginGroupware(LoginArgs args)
    {
        using var pw = await Playwright.CreateAsync();
        var browser = await pw.Chromium.LaunchAsync(new() { Channel = "msedge", Headless = false });
        var page = await (await browser.NewContextAsync(new() { ViewportSize = null })).NewPageAsync();

        await page.GotoAsync("https://groupware.lig.kr/login", new() { WaitUntil = WaitUntilState.NetworkIdle });
        await page.FillAsync("#username", args.username);
        await page.FillAsync("#password", args.password);
        await page.ClickAsync("#login_submit, .btn_login");
        await page.WaitForLoadStateAsync(LoadState.NetworkIdle);

        // 로그인 성공/실패 간단 판별(필요 시 더 정교하게)
        if (page.Url.Contains("/login"))
            return "login_failed";
        return "ok";
    }
}