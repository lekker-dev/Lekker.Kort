# Lekker.Kort URL Modifier

Tired of drab, informative URLs?  Why not inject some 'lekker' flavour into your links with Lekker.Kort!  Using our patented<sup>[1]</sup> lekkerification algorithm<sup>[2]</sup> you too can give have lekker URL!

<sup>[1] not even slightly patented</sup>
<sup>[2] very simple number-text lookup</sup>

## Description

This is a simple URL modifier application made to practice Angular with .net Core.  The application stores the given URL in a SQLite DB and on request redirects you back to the original URL.

## Demo

Live demo can be seen here: https://lekkerkort.azurewebsites.net/

## Building and Running

Ensure you have .net core 3.1 installed and then run:

``` powershell

git clone https://github.com/lekker-dev/Lekker.Kort.git

cd Lekker.Kort
dotnet restore

cd Lekker.Kort
dotnet run

```

You should then be able to browse to https://localhost:5001 to test the site out (takes a while for Angular to spin up on initial hit).

Logs and SQLite db (lekker.db by default) should all be in the "bin\Debug\netcoreapp3.1" folder.

## Technologies

.net Core 3.1
Angular 8.2
SQLite

## Contributing

Feel free to fork or PR if you want to add something, it should be very simple to add new types of unique ID generators and the controllers to use them.