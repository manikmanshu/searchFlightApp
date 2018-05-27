## Search Flights Command line application

### Usage 

```
searchFlights -o {Origin} -d {Destination}

where Args:
-o - Origin, mandatory
-d - Destination, mandatory
```

**For Example:**
```
searchFlights -o YYZ -d YYC
```

###  Output
```
{Origin} --> {Destination} ({Departure Time} --> {Destination Time}) - {Price}
```

If no flight matches then

```
No Flights Found for {Origin} --> {Destination}
```

### Run Application Locally

- Open SearchFlight.sln in Visual Studio
- Select Debug as Solution configuration
- Open SearchFlight.csproj Properties
- On **debug** tab update start options as your command line options