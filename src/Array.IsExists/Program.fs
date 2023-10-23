open System.Collections.Generic

let checkIfExist (arr: int array) =
    let set = HashSet<int>()
    let rec helper i =
        if i >= arr.Length then false
        elif set.Contains(arr[i] * 2) || (arr[i] % 2 = 0 && set.Contains(arr[i] / 2)) then true
        else 
            set.Add(arr[i]) |> ignore
            helper (i + 1)
    helper 0


printfn $"%A{checkIfExist [|10;2;5;3|]}" 

printfn $"%A{checkIfExist [|3;1;7;11|]}" 
