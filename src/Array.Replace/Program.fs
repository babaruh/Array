let replaceElements (arr: int array) : int array =
    let n = arr.Length
    let mutable maxRight = -1
    for i in (n - 1) .. -1 .. 0 do
        let temp = arr.[i]
        arr.[i] <- maxRight
        maxRight <- max maxRight temp
    arr

let arr = [|17;18;5;4;6;1|]
let arr1 = [|400|]
let result = replaceElements arr
let result1 = replaceElements arr1

printfn $"%A{result}"
printfn $"%A{result1}"
