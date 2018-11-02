Løsningen består af en .NET Core Console App og en .NET Standart Class Library

Design beslutninger

Jeg har valgt at repræsenter det forskellige dele af et bowling spil som C# objekter.

Forretningslogikken vedr. spil reglerne har jeg valgt at ligge ind i en IGameRules, da det give mulighed 
for at lave det samme spil, men med foskellige spilleregler. Udover det bliver delingen af reglerne mellem andre objekter meget lettere.

For at gøre nemt at udskifte logikken for "Roll" processeringen har jeg valgt at implementere en default roll processing strategy, 
sammen med en factory method.

Bowling.Core appen er implementeret ifølge SOLID principperne, hvor f.eks. Interface segregation princippet kan ses ved 
IBowlingGame og IEventDrivenBowlingGame.