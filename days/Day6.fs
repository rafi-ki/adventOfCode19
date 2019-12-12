module Day6

let inputLines = Set.ofSeq(System.IO.File.ReadLines "input/day6.txt")

type object = { Id: string; OrbitedBy: object list; Depth: int }

let createObjectRaw id depth = { Id = id; OrbitedBy = List.empty; Depth = depth }

let rec createObject object (values: (string * string) list) =
    let possibleOrbiter = values |> List.filter (fun x -> fst(x) = object.Id)
    if List.length possibleOrbiter = 0 then object
    else
        let objectStrings = possibleOrbiter |> List.map (fun x -> snd(x))
        let objects = objectStrings |> List.map (fun x -> createObjectRaw x (object.Depth + 1))
        let orbitedBy = objects |> List.map (fun x -> createObject x values)
        { object with OrbitedBy = orbitedBy }
        
let rec getTotalDepth object =
    let innerDepth = object.OrbitedBy |> List.sumBy getTotalDepth
    object.Depth + innerDepth
        
let partOne =
    printfn "Day 6 part 1"
    let objects = inputLines |> List.ofSeq |> List.map (fun x -> x.Substring(0, 3), x.Substring(4,3))
    let result = createObject (createObjectRaw "COM" 0) objects
    getTotalDepth result |> string