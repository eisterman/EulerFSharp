module EulerFSharp.Problem3
  
let rec construct_primes maxn n primes =  // n = 3 primes = [2;]
    match n with
    | _ when n > maxn -> primes
    | _ when List.forall (fun x -> n % x <> 0UL) primes -> construct_primes maxn (n+1UL) (n :: primes)
    | _ -> construct_primes maxn (n+1UL) primes
   
let primes_until maxn = construct_primes maxn 3UL [2UL;]

let input = 600851475143UL

let result = input |> double |> sqrt |> uint64 |> primes_until |> List.find (fun x -> input % x = 0UL)
