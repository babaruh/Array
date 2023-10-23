open Xunit
open FsUnit.Xunit

let findNumbersWithEvenNumberOfDigits nums =
    let isEven x = x % 2 = 0
    nums
    |> Array.map (fun num -> num.ToString().Length)
    |> Array.filter isEven
    |> Array.length

// Input: nums = [12, 345, 2, 6, 7896] 
let nums = [|12; 345; 2; 6; 7896|]

printfn $"%A{findNumbersWithEvenNumberOfDigits nums}"


[<Fact>]
let ``findNumbersWithEvenNumberOfDigits with [555; 901; 482; 1771] should equal 1``() =
    findNumbersWithEvenNumberOfDigits [|555; 901; 482; 1771|] |> should equal 1

[<Fact>]
let ``maxConsecutiveOnes with [12; 345; 2; 6; 7896] should equal 2``() =
    findNumbersWithEvenNumberOfDigits [|12; 345; 2; 6; 7896|] |> should equal 2

[<Fact>]
let ``maxConsecutiveOnes with empty list should equal 0``() =
    findNumbersWithEvenNumberOfDigits [||] |> should equal 0
