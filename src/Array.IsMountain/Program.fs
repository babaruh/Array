let isMountainArray (arr: int array) : bool =
    let n = arr.Length
    if n < 3 then false
    else
        let mutable i = 0
        while i + 1 < n && arr[i] < arr[i + 1] do
            i <- i + 1
        if i = 0 || i = n - 1 then false
        else
            while i + 1 < n && arr[i] > arr[i + 1] do
                i <- i + 1
            i = n - 1

let arr1 = [|2; 1|]
let arr2 = [|3; 5; 5|]
let arr3 = [|0; 3; 2; 1|]

let res1 = isMountainArray arr1
let res2 = isMountainArray arr2
let res3 = isMountainArray arr3

printfn $"1: %A{res1}"
printfn $"2: %A{res2}"
printfn $"3: %A{res3}"
