open System
open Xunit
open FsUnit.Xunit

let maxConsecutiveOnes (nums: int list) =
    let rec loop count maxCount = function
        | [] -> max maxCount count
        | 0 :: tail -> loop 0 (max maxCount count) tail
        | 1 :: tail -> loop (count + 1) maxCount tail
        | _ -> invalidArg "nums" "nums must contain only 1 or 0"
    loop 0 0 nums

let nums = [1;0;1;1;0;1]


printfn $"%A{maxConsecutiveOnes nums}"


[<Fact>]
let ``maxConsecutiveOnes with all zeros``() =
    maxConsecutiveOnes [0; 0; 0; 0; 0] |> should equal 0

[<Fact>]
let ``maxConsecutiveOnes with 5 ones``() =
    maxConsecutiveOnes [1; 1; 1; 1; 1] |> should equal 5

[<Fact>]
let ``maxConsecutiveOnes with mixed zeros and ones``() =
    maxConsecutiveOnes [1; 1; 0; 1; 1; 1] |> should equal 3

[<Fact>]
let ``maxConsecutiveOnes with empty list``() =
    maxConsecutiveOnes [] |> should equal 0

[<Fact>]
let ``maxConsecutiveOnes with invalid input``() =
    Assert.Throws<ArgumentException> (fun () -> maxConsecutiveOnes [-1] |> ignore)
