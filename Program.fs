// Learn more about F# at http://fsharp.org
module Program
open System

let print = printfn "%s"

[<EntryPoint>]
let main argv =
    printfn "Hello World I'm ready for advent of code"
//    DayOne.partOne() |> printDay
//    DayOne.partTwo() |> printDay
//    DayTwo.partOne() |> printDay
//    DayThree.partOne |> printDay
//    DayThree.partTwo |> printDay
//    DayFour.partOne |> printDay
//    DayFour.partTwo |> printDay
//    Day5.partOne |> printDay
//    Day6.partOne |> printDay
//    Day6.partTwo |> printDay
//    Day7.partOne |> printDay
//    Day8.partOne |> printDay
    Day8.partTwo |> print
    
    Console.ReadLine() |> ignore
    0
