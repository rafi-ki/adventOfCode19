module DayOne

let calculateFuel mass = mass / 3 - 2

let inputLines = System.IO.File.ReadLines "input/day1.txt"

let rec calculateFuelRec mass =
    let fuel = calculateFuel mass
    if fuel <= 0 then
        System.Math.Max(fuel, 0)
    else
        fuel + calculateFuelRec fuel

let partOne() =
    printfn "day 1"
    inputLines
        |> List.ofSeq
        |> List.map int
        |> List.map calculateFuel
        |> List.sum
        |> string
    
let partTwo() =
    printfn "day 1 part 2"
    inputLines
        |> List.ofSeq
        |> List.map int
        |> List.map calculateFuelRec
        |> List.sum
        |> string