# LNTestChallenge

My solution for the coding challenge from LiveNation.
Derived from the Web API template for .NET Core.

## Author

Omar Ajerray

## Tools

- Visual Studio Code
- Chrome OS/debian arm64
- Git
- Postman Chrome Extension
- .NET Core SDK 3.1
- Asp.NET Core runtime 3.1

## Build

_BASH_

When the dotnet sdk is installed, run `dotnet build` in the project root directory. 

## Run

_BASH_

When built, run `dotnet run --project ./LNTestChallenge/LNTestChallenge.csproj` in the project root directory to start the web API. then navigate to the URL shown in the Ouptput plus one of the endpoints described further in the document.

## Test

_BASH_

When built, run `dotnet test` in the project root directory to run the tests.

## API Endpoints

### [HostUrl]/LiveNationCodeChallenge/RuleSet

_[GET]_

Returns a JSON Object of an Example `RulesSet`.

__Example Output__
``` JSON
{
    "rules": [
        {
            "dividers": [
                3
            ],
            "phrase": "Live"
        },
        {
            "dividers": [
                5
            ],
            "phrase": "Nation"
        },
        {
            "dividers": [
                3,
                5
            ],
            "phrase": "LiveNation"
        }
    ]
}
```

### [HostUrl]/LiveNationCodeChallenge/GetResult?RangeStart=[int]&RangeEnd=[int]

_[POST], [Params], [`RuleSet` JSON Body]_

Accepts a `RuleSet` JSON Object in the body and two parameters that decribe the range start and end. will return a `ResultDto` with the result string and a summary.

_Note:_ the order of rules is relevant in deciding which matching ones get applied.

__Example Input__
``` JSON
{
    "rules": [
    	{
            "dividers": [3,5],
            "phrase": "LiveNation"
        },
    	{
            "dividers": [3],
            "phrase": "Live"
        },
               {
            "dividers": [5],
            "phrase": "Nation"
        }
    ]
}
```

__Example Output__

``` JSON
{
    "result": "1 2 Live 4 Nation Live 7 8 Live Nation 11 Live 13 14 LiveNation 16 17 Live 19 Nation",
    "summary": {
        "Integer": 11,
        "Live": 5,
        "Nation": 3,
        "LiveNation": 1
    }
}
```