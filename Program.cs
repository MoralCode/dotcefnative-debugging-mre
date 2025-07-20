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
		cef.Start("--disable-web-security");
		var window = await cef.CreateWindowAsync(
			"https://fast.com",
			(int)(1000),
			(int)(1000),
			(int)(1000),
			(int)(1000), title: "test", developerToolsEnabled: true, proxyRequests: false, modifyRequests: false, modifyRequestBody: false, logConsole: true, resizable: true);
		await window.LoadUrlAsync("https://www.google.com");
		await window.WaitForExitAsync();
	}

}