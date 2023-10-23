let duplicateZeros (arr: int array) =
    let mutable i = 0
    while i < arr.Length do
        if arr[i] = 0 then
            for j in (arr.Length - 1) .. -1 .. (i + 1) do
                arr[j] <- arr[j - 1]
            if i < arr.Length - 1 then
                arr[i + 1] <- 0
            i <- i + 2
        else
            i <- i + 1


let arr = [| 1; 0; 2; 3; 0; 4; 5; 0 |]

let res = duplicateZeros arr

printfn $"%A{arr}"
