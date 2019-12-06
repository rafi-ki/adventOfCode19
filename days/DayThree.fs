module DayThree

type Direction = Up | Down | Right | Left
type Movement = { Direction: Direction; Distance: int }
type Wire = Movement[]
let createDirection c = match c with
                        | 'U' -> Up
                        | 'D' -> Down
                        | 'R' -> Right
                        | 'L' -> Left
                        | _ -> failwith "no such direction"
let createMovement (i: string) = { Direction = createDirection i.[0]; Distance = i.[1..] |> int }

let partOne =
    printfn "day 3 part 1"
    let readLines = System.IO.File.ReadAllLines "input/day3.txt"
    let textToWire (text:string) = text.Split [|','|] |> Array.map createMovement
    let wire1 = textToWire readLines.[0]
    let wire2 = textToWire readLines.[1]
    
    "worked"