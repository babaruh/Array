# Масиви на F#

## Встановлення

Для запуску цього проекту вам потрібно мати встановлений комп'ютер F# compiler та dotnet core. Ви також можете скористатися онлайн-компілятором F#, наприклад repl.it.

## Використання

Ви можете запустити цей проект за допомогою команди `dotnet run` у терміналі або скопіювати код у онлайн-компілятор. Кожна функція приймає певний тип аргументу та повертає певний тип результату. Ось приклади виклику кожної функції:

```fsharp
// 1 Максимальна кількість повторень
let maxConsecutiveOnes (nums: int list) =
    let rec loop count maxCount = function
        | [] -> max maxCount count
        | 0 :: tail -> loop 0 (max maxCount count) tail
        | 1 :: tail -> loop (count + 1) maxCount tail
        | _ -> invalidArg "nums" "nums must contain only 1 or 0"
    loop 0 0 nums

let nums = [1;0;1;1;0;1]

printfn $"%A{maxConsecutiveOnes nums}"

// 2 Знайдіть числа з парною кількістю цифр
let findNumbersWithEvenNumberOfDigits nums =
    let isEven x = x % 2 = 0
    nums
    |> Array.map (fun num -> num.ToString().Length)
    |> Array.filter isEven
    |> Array.length

let nums = [|12; 345; 2; 6; 7896|]

printfn $"%A{findNumbersWithEvenNumberOfDigits nums}"\

// 3 Квадрати відсортованого масиву
let squareAndSort (nums: int array) =
    nums |> Array.map (fun x -> x * x) |> Array.sort

squareAndSort [| -4; -1; 0; 3; 10 |] |> printfn "%A"

// 4 Подвійні нулі
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

// 5 Об’єднати відсортований масив
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

// 6 Видалити дублікати з відсортованого масиву
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

// 7 Перевірте, чи існують N і його подвійник
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

// 8 Дійсний гірський масив
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

// 9 Замініть елементи на найбільший елемент з правого боку
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

// 10 Відсортувати масив за парністю
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
```