let sortArrayByParity (nums: int array) : int array =
    let n = nums.Length
    let mutable i = 0
    let mutable j = n - 1
    while i < j do
        if nums[i] % 2 > nums[j] % 2 then
            let temp = nums[i]
            nums[i] <- nums[j]
            nums[j] <- temp
        if nums[i] % 2 = 0 then i <- i + 1
        if nums[j] % 2 = 1 then j <- j - 1
    nums
    
let nums = [|3;1;2;4|]
let nums1 = [|0|]
let result = sortArrayByParity nums
let result1 = sortArrayByParity nums1
printfn $"%A{result}"
printfn $"%A{result1}"
