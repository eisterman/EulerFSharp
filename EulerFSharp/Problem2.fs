module EulerFSharp.Problem2

let rec construct_fibduo idx =
    match idx with
    | 0 -> 1, 0
    | 1 -> 1, 1
    | _ ->
        let precfib = idx - 1 |> construct_fibduo
        fst precfib + snd precfib, fst precfib

let result =
    (fun x -> construct_fibduo x |> fst) |>
    Seq.initInfinite |>
    Seq.takeWhile (fun x -> x < 4_000_000) |>
    Seq.filter (fun x -> x % 2 = 0) |>
    Seq.sum
