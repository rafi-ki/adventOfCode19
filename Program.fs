// Learn more about F# at http://fsharp.org
module Program
open System


[<EntryPoint>]
let main argv =
    printfn "Hello World I'm ready for advent of code"
    let readLine = Console.ReadLine();
    let result = match readLine with
                    | "1" -> DayOne.partOne()
                    | "1.2" -> DayOne.partTwo()
                    | "2" -> DayTwo.partOne
                    | _ -> "the day has not come yet"
    printfn "%s" result
    0
