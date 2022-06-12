module EulerFSharp.Program

[<EntryPoint>]
let main _args =
    printf "What ProjectEuler Problem do you want to run?: "
    let str = System.Console.ReadLine()
    let pnum = System.Int32.Parse str
    let result =
        match pnum with
        | 1 -> Problem1.result
        | 2 -> Problem2.result
        | 3 -> Problem3.result |> int
        | 4 -> Problem4.result
        | _ -> raise (System.ArgumentException("Problem requested doesn't exists"))
    printfn $"Result Problem {pnum}:\n{result}"
    0
