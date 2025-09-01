// Nuget 콘솔에서 설치
// Install-Package ModelContextProtocol -Prerelease
// Install - Package ModelContextProtocol.AspNetCore - Prerelease

using System.ComponentModel;
using System.Windows;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ModelContextProtocol.Server;
using ModelContextProtocol.AspNetCore;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace MCPServer1
{
    public partial class App : Application
    {
        private IHost? _webHost;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // 1) Kestrel 직접 구성: 포트/주소 고정
            var builder = WebApplication.CreateBuilder();
            builder.WebHost.UseUrls("http://127.0.0.1:5000");   // 필요시 0.0.0.0로

            // 2) MCP 서버 + HTTP 전송 + 툴 등록 (★ 핵심)
            builder.Services
                   .AddMcpServer()
                   .WithHttpTransport()        // << 이게 없으면 방금 그 예외 발생
                   .WithToolsFromAssembly();

            var app = builder.Build();

            // 3) MCP 엔드포인트 경로 명시
            app.MapMcp("/mcp");

            // 4) 서버 시작
            app.Start();

            _webHost = app;
        }

        protected override void OnExit(ExitEventArgs e)
        {
            _webHost?.Dispose();
            base.OnExit(e);
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
            result = await session.call_tool("show_message", {"message": "안녕하세요, MCP from Python!"})
            for c in result.content:
                if c.type == "text":
                    print("RESULT:", c.text)

if __name__ == "__main__":
    asyncio.run(main()) 
 
*/