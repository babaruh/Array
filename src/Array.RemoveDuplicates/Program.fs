let removeDuplicates (nums: int array) =
    if nums.Length = 0 then 0
    else
        let mutable i = 0
        for j in 1 .. nums.Length - 1 do
            if nums[j] <> nums[i] then
                i <- i + 1
                nums[i] <- nums[j]
        for j in i+1 .. nums.Length - 1 do
            nums[j] <- -101 
        i + 1

let nums = [| 0; 0; 1; 1; 1; 2; 2; 3; 3; 4 |]

let result = removeDuplicates nums

printfn $"%A{result}"
printfn $"%A{nums}"
