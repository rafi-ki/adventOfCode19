module Day8

let inline charToInt c = int c - int '0'

type Line = { Digits: int [] }
type Layer = { Lines : Line [] }
type Image = { Layers: Layer [] }

let width = 25
let height = 6

let createLine v = Array.create v
let createLayer v = Array.create v



let numberOfZeroes (input: int[][]) =
    let nOfZ v = Array.sumBy (fun x -> if x = 0 then 1 else 0) v
    input |> Array.sumBy (fun x -> nOfZ x)

let numberOfOnes (input: int[][]) =
    let nOfZ v = Array.sumBy (fun x -> if x = 1 then 1 else 0) v
    input |> Array.sumBy (fun x -> nOfZ x)
    
let numberOfTwos (input: int[][]) =
    let nOfZ v = Array.sumBy (fun x -> if x = 2 then 1 else 0) v
    input |> Array.sumBy (fun x -> nOfZ x)

let partOne =
    let readInput = System.IO.File.ReadAllText "input/day8.txt"
    let input = Seq.toList readInput |> Seq.map charToInt |> Array.ofSeq
    let layers = input
                |> Array.chunkBySize width
                |> Array.chunkBySize height
                
    let minZeroLayer = layers |> Array.minBy numberOfZeroes
    let numberOfOnes = numberOfOnes minZeroLayer
    let numberOfTwos = numberOfTwos minZeroLayer
    numberOfOnes * numberOfTwos |> string 