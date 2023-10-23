let squareAndSort (nums: int array) =
    nums |> Array.map (fun x -> x * x) |> Array.sort

squareAndSort [| -4; -1; 0; 3; 10 |] |> printfn "%A"
