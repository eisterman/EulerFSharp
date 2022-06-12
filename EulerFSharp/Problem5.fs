module EulerFSharp.Problem5

(*
Il problema 5 consiste nel prendere i primi 20 numeri da 1 a 20, scomporli in fattori primi e ottenere una lista
che contenga il numero minimo necessario di ogni fattore primo per fattorizzare tutti quei numeri.
Ad esempio dato da 1 a 10, fattorizzi 8 che da [2,2,2] che in automatico copre anche 2 e 4.
Per essi il numero minimo richiesto di insieme di fattori primi per fattorizzare tutti e 10 i numeri è 
[2, 2, 2, 3, 3, 5, 7] che moltiplicati danno 2520 che è il risultato corretto.

Eseguire la stessa cosa per numeri da 1 a 20.

Il test di fattorizzazione su n può essere fatto da 2 a sqrt(n).
Questo vuol dire che se i è il numero di test ed il ciclo while normalmente sarebbe `while i <= sqrt(n)`, esso
può essere trasformato in `while i^2 <= n` per ridurre i calcoli eseguiti.
*)

let rec construct_factorize_map n i =
    match n with
    | 1 -> Map.empty
    | _ when n % i = 0 ->
        let other: Map<int,int> = construct_factorize_map (n / i) i
        if other.ContainsKey i then
            other.Change (i, (fun x -> match x with | Some c -> c+1 |> Some | None -> None))
        else
            other.Add (i, 1)
    | _ when i * i > n ->
        Map.empty.Add (n, 1)
    | _ ->
        construct_factorize_map n (i+1)

let prime_factorize n =
    match n with
    | 1 -> Map.empty.Add (1,1)
    | _ when n >= 2 -> construct_factorize_map n 2
    | _ -> raise (System.ArgumentException "Required integer greater than 0")

let map_merge (map1: Map<int,int>) (map2: Map<int,int>) =
    let folder (m1: Map<int,int>) key value =
        if m1.ContainsKey key then
            m1.Change (key, (fun x -> match x with | Some c -> max c value |> Some | None -> None))
        else
            m1.Add (key, value)
    Map.fold folder map1 map2

let result = [2 .. 20]
             |> List.map prime_factorize
             |> List.fold map_merge Map.empty
             |> Map.fold (fun acc key value -> acc * int(float(key) ** value)) 1
