// Learn more about F# at http://fsharp.org
module Program
open System

let printDay = printfn "%s"

[<EntryPoint>]
let main argv =
    printfn "Hello World I'm ready for advent of code"
//    DayOne.partOne() |> printDay
//    DayOne.partTwo() |> printDay
//    DayTwo.partOne() |> printDay
//    DayThree.partOne |> printDay
//    DayThree.partTwo |> printDay
    DayFour.partOne |> printDay
    
    Console.ReadLine() |> ignore
    0
