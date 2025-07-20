using DotCef;


class Program
{
	
	static async Task Main(string[] args)
	{

		string defaultUrl = "https://fast.com";
		string targetUrl = defaultUrl;
		List<string> cefArgs = new();

		foreach (var arg in args)
		{
			if (arg.StartsWith("--url="))
			{
				targetUrl = arg.Substring("--url=".Length);
			}
			else
			{
				cefArgs.Add(arg);
			}
		}


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
		string extraArgs = string.Join(" ", cefArgs);

		cef.Start($"--disable-web-security --ozone-platform-hint=wayland --enable-features=WaylandWindowDecorations --use-alloy-style --user-data-dir=./chromium-data-dir --log-file=cef.log --no-sandbox {extraArgs}");

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