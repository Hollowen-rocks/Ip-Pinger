# Interactive IP Pinger with Response Time

This F# script continuously pings a specified IP address and checks its response time. It uses the `ping` command-line tool available in most operating systems to determine if the host is reachable and measures the response time in milliseconds.

## Requirements

- [.NET Core SDK](https://dotnet.microsoft.com/download) or [Mono](https://www.mono-project.com/download/stable/) for running F# scripts.

## 1. Enter the IP Address

- When prompted, enter or paste the IP address you want to ping, then press Enter.

## 2. Output:

- The script will continuously ping the specified IP address every second.
- It will print whether the host is reachable and its response time in milliseconds if reachable.

## Example

```
Enter the IP address to ping: 8.8.8.8
```
```sh
8.8.8.8 is reachable with response time: 12ms
8.8.8.8 is reachable with response time: 11ms
8.8.8.8 is not reachable
8.8.8.8 is reachable with response time: 10ms
...
```

- Ensure that the IP address you enter is reachable from your network.
- The script uses a regular expression to parse the response time from the ping output. The pattern may need adjustment based on your system's ping command output format.
