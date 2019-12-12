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

type TwoAdjacent = { Last: int; BeforeLast: int; Pass: bool }

let twoAdjacentAreSameExact (value: seq<int>) =
    let adjust x y =
        if x.Pass then x
        else
            if y = x.Last && (y = x.BeforeLast) |> not && (x.BeforeLast = -1) |> not then
                { x with Pass = true }
            else 
                { Last = y; BeforeLast = x.Last; Pass = false }
    
    let initial = { Last = -1; BeforeLast = -1; Pass = false }
    let result = Seq.fold adjust initial value
    if result.Last = result.BeforeLast && Seq.item 3 value = result.Last then true
    else result.Pass

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
