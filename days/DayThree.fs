module DayThree

type Direction = Up | Down | Right | Left
type Movement = { Direction: Direction; Distance: int }
type Point = { X: int; Y: int }
type StepPoint = { Point: Point; Steps: int }
type Wire = Point list

let createDirection c = match c with
                        | 'U' -> Up
                        | 'D' -> Down
                        | 'R' -> Right
                        | 'L' -> Left
                        | _ -> failwith "no such direction"
let createMovement (i: string) =
    { Direction = createDirection i.[0]; Distance = i.[1..] |> int }

let moveOne direction start =
    match direction with
            | Up -> {start with Y = start.Y + 1 }
            | Down -> {start with Y = start.Y - 1}
            | Right -> {start with X = start.X + 1}
            | Left -> {start with X = start.X - 1}
            
let addStep stepPoint = { stepPoint with Steps = stepPoint.Steps + 1 }

let moveOneStep direction start =
    let nextPoint = moveOne direction start.Point
    addStep { Point = nextPoint; Steps = start.Steps }
            
let move (point: Point) movement =
    let moveTo = moveOne movement.Direction
    let mutable moves = []
    for i in 1..movement.Distance do
        let currentHead = if List.length moves = 0 then point else List.head moves
        let head = moveTo currentHead
        moves <- head :: moves
    moves

let moveSteps (point: StepPoint) movement =
    let moveTo = moveOneStep movement.Direction
    let mutable moves = []
    for i in 1..movement.Distance do
        let currentHead = if List.length moves = 0 then point else List.head moves
        let head = moveTo currentHead
        moves <- head :: moves
    moves

let manhattenDistance point = System.Math.Abs point.X + System.Math.Abs point.Y
    
let partOne =
    printfn "day 3 part 1"
    let readLines = System.IO.File.ReadAllLines "input/day3.txt"
    let textToWire (text:string) = text.Split [|','|] |> Array.map createMovement
    let wire1 = textToWire readLines.[0]
    let wire2 = textToWire readLines.[1]
    let mutable moves = []
    for movement in wire1 do
        let currentHead = if List.length moves = 0 then {X = 0; Y = 0} else List.head moves
        let head = move currentHead movement
        moves <- List.append head moves
    let mutable moves2 = []
    for movement in wire2 do
        let currentHead = if List.length moves2 = 0 then {X = 0; Y = 0} else List.head moves2
        let head = move currentHead movement
        moves2 <- List.append head moves2
    let intersections = Set.intersect (Set.ofList moves) (Set.ofList moves2) |> Set.toList
    intersections |> List.minBy manhattenDistance |> manhattenDistance |> string
    

let totalSteps a b = a.Steps + b.Steps

let matches point stepPoint = point = stepPoint.Point

let first point stepPoints = List.head (List.filter (fun x -> x.Point = point) stepPoints)

let partTwo =
    printfn "day 3 part 2"
    let readLines = System.IO.File.ReadAllLines "input/day3.txt"
    let textToWire (text:string) = text.Split [|','|] |> Array.map createMovement
    let wire1 = textToWire readLines.[0]
    let wire2 = textToWire readLines.[1]
    let centralPort = {Point = {X = 0; Y = 0}; Steps = 0}
    let mutable moves = []
    for movement in wire1 do
        let currentHead = if List.length moves = 0 then centralPort  else List.head moves
        let head = moveSteps currentHead movement
        moves <- List.append head moves
    let mutable moves2 = []
    for movement in wire2 do
        let currentHead = if List.length moves2 = 0 then centralPort else List.head moves2
        let head = moveSteps currentHead movement
        moves2 <- List.append head moves2
    let intersectionPoints = Set.intersect (Set.ofList (moves |> List.map (fun (x) -> x.Point))) (Set.ofList (moves2 |> List.map (fun (x) -> x.Point))) |> Set.toList
    
    let something = intersectionPoints |> List.map (fun x -> ((first x moves).Steps + (first x moves2).Steps))
    something |> List.min |> string