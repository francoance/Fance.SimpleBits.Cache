# Fance.SimpleBits.Cache
![GitHub Workflow Status](https://img.shields.io/github/workflow/status/francoance/Fance.SimpleBits.Cache/Build%20and%20test?label=Build%20and%20test) ![Nuget](https://img.shields.io/nuget/dt/Fance.SimpleBits.Cache?label=Downloads) ![Nuget](https://img.shields.io/nuget/v/Fance.SimpleBits.Cache?label=Current%20version)

## What is this?
Check my [Fance.SimpleBits.General repository](https://github.com/francoance/Fance.SimpleBits.General/blob/main/README.md) ☺.

## No, seriously, what is this?
If you've read the linked readme and you've read the repository's title, then you might already know what this is!

This is my cache implementation, simplified enough to download and make it work without tinkering too much.

## Usage
#### Installation
Download and install the package to your projects.
>Install-Package Fance.SimpleBits.Cache

#### Add the required configuration
On the root of your settings file add the following entry:
```json
"Cache": {
    "Host": "your-redis-host:your-redis-port",
    "Password": "your-redist-password"
}
```
If the Host key is not found, `localhost:6379` is used by default.
If the Password key is not found, nothing is used.

If you need to use additional parameters, you could use the Host value as a connection string and append it there, like so `"Host": "localhost:6379, ssl=true, allowAdmin=true"`.

#### Add the service
Hook the service registration to your service collector, and pass your configuration object, using:
>services.AddSimpleRedisCache(Configuration);

Remember to add the using for this:
>using Fance.SimpleBits.Cache.DependencyInjection

#### Done!
After this, you can just request a ISimpleCache object through DI and use any of the following methods:
+ `void Save(string key, string value)`: Saves a string with a key identifier.
+ `Task SaveAsync(string key, string value)`: Saves a string with a key identifier, asynchronically.
+ `string Find(string key)`: Finds an object on the cache using a key identifier. 
+ `Task<string> FindAsync(string key)`: Finds an object on the cache using a key identifier, asynchronically.

## You don't like it?
This is licensed under the [MIT license](./License.md). This is the open source world, go ahead, fork it and make it your own. If you like what you do, just send a PR!
