# About The Project
MatchCityNameApi is a RESTful Web API implemented in C# using a minimal API approach. 
It serves as a city autocompletion service, allowing users to send requests with partial city names, 
and in return, it provides a JSON response containing cities that match the provided input. The API 
utilizes a database with information on over 140,000 cities worldwide.
The JSON response includes full city name and key details like latitude, longitude, population and other, sorted
by population order.

# API Endpoint
The primary endpoint for city matching is:
`/api/cities?startsWith={input string}`

### Parameters
**startsWith** (required): The input string representing the beginning of the city name.
**limit** (optional): An additional parameter to limit the number of cities in the JSON response. 

### Example of API call
`/api/cities?startsWith=Be&limit=3`

### Example API response
`[
  {
    "id": "6558925957ff08f32fc484cd",
    "name": "Beijing",
    "ascii_name": "Beijing",
    "country_code": "CN",
    "cou_name_en": "China",
    "country_code_2": null,
    "population": 18960744,
    "timezone": "Asia/Shanghai",
    "label_en": "China",
    "lon": 116.39723,
    "lat": 39.9075
  },
  {
    "id": "6558925d57ff08f32fc4f49e",
    "name": "Bengaluru",
    "ascii_name": "Bengaluru",
    "country_code": "IN",
    "cou_name_en": "India",
    "country_code_2": null,
    "population": 8443675,
    "timezone": "Asia/Kolkata",
    "label_en": "India",
    "lon": 77.59369,
    "lat": 12.97194
  },
  {
    "id": "6558925957ff08f32fc48f91",
    "name": "Berlin",
    "ascii_name": "Berlin",
    "country_code": "DE",
    "cou_name_en": "Germany",
    "country_code_2": null,
    "population": 3426354,
    "timezone": "Europe/Berlin",
    "label_en": "Germany",
    "lon": 13.41053,
    "lat": 52.52437
  }
]`

### Fields in API response
- *id* Unique id
- *name* City name
- *ascii_name* ASCII city name
- *country_code* Country code
- *cou_name_en* Country name in English
- *country_code_2* Country code (optional)
- *population* Number of population, intiger
- *timezone* Timezone name
- *label_en* English label
- *lon*  Longitude of the location, decimal (-180; 180) 
- *lat* Latitude of the location, decimal (−90; 90)

# Code

# Contributing
If you wish to contribute to this project, please feel free to create a pull request with your changes.
# License
This project is licensed under the MIT License - see the LICENSE file for details.
