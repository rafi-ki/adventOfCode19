module DayFour

let input = "125730-579381"
let lower = 125730
let upper = 579381

let createDigits (value: int) =
    value |> string |> Seq.toList |> Seq.map (fun x -> int x - int '0')

let digitsIncrease (value: seq<int>) =
    value |> Seq.pairwise |> Seq.filter (fun (x, y) -> x > y) |> Seq.isEmpty
    
let twoAdjacentAreSame value =
    Seq.windowed 2 value |> Seq.exists (fun x -> x.[0] = x.[1])

let twoAdjacentAreSameExact value =
    let sameValueAt 
    let eligible = Seq.windowed 2 value |> Seq.filter (fun x -> x.[0] = x.[1])
    let unequalPairs = Seq.windowed 2 eligible |> Seq.filter (fun x -> not (x.[0].[0] = x.[1].[0]))
    Seq.length unequalPairs > 0

let meetsCriteria (value: seq<int>) =
    value |> digitsIncrease && twoAdjacentAreSame value
    
let meetsCriteria2 (value: seq<int>) =
    value |> digitsIncrease && twoAdjacentAreSameExact value

let partOne =
    printfn "Day 4 part 1"
    [lower..upper]
    |> Seq.map createDigits
    |> Seq.filter meetsCriteria
    |> Seq.length |> string

let partTwo =
    printfn "Day 4 part 2"
    [lower..upper]
    |> Seq.map createDigits
    |> Seq.filter meetsCriteria2
    |> Seq.length |> string
