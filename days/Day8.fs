module Day8

let inline charToInt c = int c - int '0'

type Line = { Digits: int [] }
type Layer = { Lines : Line [] }
type Image = { Layers: Layer [] }

let width = 25
let height = 6

let createLine v = Array.create v
let createLayer v = Array.create v

let countOfNumber (input: int[][]) number =
    let nOfX v = Array.sumBy (fun x -> if x = number then 1 else 0) v
    input |> Array.sumBy nOfX
    
let countNumber0 input = countOfNumber input 0
let countNumber1 input = countOfNumber input 1
let countNumber2 input = countOfNumber input 2

let partOne =
    let readInput = System.IO.File.ReadAllText "input/day8.txt"
    let input = Seq.toList readInput |> Seq.map charToInt |> Array.ofSeq
    let layers = input
                |> Array.chunkBySize width
                |> Array.chunkBySize height
                
    let minZeroLayer = layers |> Array.minBy countNumber0
    let numberOfOnes = countNumber1 minZeroLayer
    let numberOfTwos = countNumber2 minZeroLayer
    numberOfOnes * numberOfTwos |> string 