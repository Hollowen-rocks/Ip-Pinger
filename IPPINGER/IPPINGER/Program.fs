open System
open System.Diagnostics
open System.Threading

let pingHost (host: string) =
    let process = new Process()
    process.StartInfo.FileName <- "ping"
    process.StartInfo.Arguments <- if Environment.OSVersion.Platform = PlatformID.Win32NT then sprintf "-n 1 %s" host else sprintf "-c 1 %s" host
    process.StartInfo.RedirectStandardOutput <- true
    process.StartInfo.UseShellExecute <- false
    process.StartInfo.CreateNoWindow <- true

    process.Start() |> ignore
    let output = process.StandardOutput.ReadToEnd()
    process.WaitForExit()

    let responseTimePattern = if Environment.OSVersion.Platform = PlatformID.Win32NT then "time=([0-9]+)ms" else "time=([0-9.]+) ms"
    let responseTimeMatch = System.Text.RegularExpressions.Regex.Match(output, responseTimePattern)

    if process.ExitCode = 0 && responseTimeMatch.Success then
        let responseTime = responseTimeMatch.Groups.[1].Value
        printfn "%s is reachable with response time: %sms" host responseTime
    else
        printfn "%s is not reachable" host

[<EntryPoint>]
let main argv =
    printf "Enter the IP address to ping: "
    let ipAddress = Console.ReadLine()
    while true do
        pingHost ipAddress
        Thread.Sleep(1000) // Sleep for 1 second
    0 // return an integer exit code
