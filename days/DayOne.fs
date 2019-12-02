module DayOne

let basePath = "C:\Dev\AdventOfCode\AdventOfCode19\days";

let calculateFuel mass = mass / 3 - 2

let rec calculateFuelRec mass =
    let fuel = calculateFuel mass
    if fuel <= 0 then
        System.Math.Max(fuel, 0)
    else
        fuel + calculateFuelRec fuel

let dayOne() =
    printfn "day 1"
    let inputLines = System.IO.File.ReadLines "days/day1.txt"
    let result = inputLines
                |> List.ofSeq
                |> List.map int
                |> List.map calculateFuel
                |> List.sum
    string result
    
let partTwo() =
    printfn "day 1 part 2"
    let inputLines = System.IO.File.ReadLines "days/day1.txt"
    let result = inputLines
                |> List.ofSeq
                |> List.map int
                |> List.map calculateFuelRec
                |> List.sum
    string result