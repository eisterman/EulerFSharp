// For more information see https://aka.ms/fsharp-console-apps

let tredigitnumbers = [100 .. 999]
let numberstotest =
    tredigitnumbers |> List.allPairs tredigitnumbers |> List.map (fun (x, y) -> x*y) |> List.sortDescending
let ispalindrome n =
    let a = string n
    let b = a.ToCharArray() |> Array.rev |> System.String  // To parse a char[] into a string we need to use the C# one
    a = b
let result = List.find ispalindrome numberstotest

printfn $"Result: {result}"