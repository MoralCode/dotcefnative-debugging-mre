using DotCef;


class Program
{
	
	static async Task Main(string[] args)
	{
		using var cef = new DotCefProcess();
		// cef.OutputDataReceived += (msg) =>
		// {
		// 	if (msg == null)
		// 		return;
		// 	Console.WriteLine(msg);
		// };
		// cef.ErrorDataReceived += (msg) =>
		// {
		// 	if (msg == null)
		// 		return;
		// 	Console.WriteLine(msg);
		// };
		string extraArgs = string.Join(" ", args);

		cef.Start($"--disable-web-security --ozone-platform-hint=wayland --enable-features=WaylandWindowDecorations --use-alloy-style --user-data-dir=./chromium-data-dir --log-file=cef.log --no-sandbox {extraArgs}");

		var targetUrl = "https://google.com";
		var window = await cef.CreateWindowAsync(
			targetUrl,
			(int)(1000),
			(int)(1000),
			(int)(1000),
			(int)(1000), title: "test", developerToolsEnabled: true, proxyRequests: false, modifyRequests: false, modifyRequestBody: false, logConsole: true, resizable: true);
		await window.LoadUrlAsync(targetUrl);
		await window.WaitForExitAsync();
	}

}