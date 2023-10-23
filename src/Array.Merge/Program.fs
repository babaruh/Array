let merge (nums1: int[]) (m: int) (nums2: int[]) (n: int) =
    let mutable i = m - 1
    let mutable j = n - 1
    let mutable k = m + n - 1

    while i >= 0 && j >= 0 do
        if nums1[i] > nums2[j] then
            nums1[k] <- nums1[i]
            i <- i - 1
        else
            nums1[k] <- nums2[j]
            j <- j - 1
        k <- k - 1

    while j >= 0 do
        nums1[k] <- nums2[j]
        j <- j - 1
        k <- k - 1

let nums1 = [| 0 |]
let m = 0
let nums2 = [| 1 |]
let n = 1

merge nums1 m nums2 n

nums1 |> printfn "%A"
