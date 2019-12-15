module Day6

let inputLines = Set.ofSeq(System.IO.File.ReadLines "input/day6.txt")

type object = { Id: string; OrbitedBy: object list; Depth: int }

type object2 = { Id: string; Orbits: object2 option; OrbitedBy: object2 list }

let createObjectRaw id depth = { Id = id; OrbitedBy = List.empty; Depth = depth }

let rec createObject (object: object) (values: (string * string) list) =
    let orbitedBy = values
                        |> List.filter (fun x -> fst(x) = object.Id)
                        |> List.map (fun x -> snd(x))
                        |> List.map (fun x -> createObjectRaw x (object.Depth + 1))
                        |> List.map (fun x -> createObject x values) 
    { object with OrbitedBy = orbitedBy }
        
let rec createObject2 (object: object2) (values: (string * string) list) =
    let orbitedBy = values
                    |> List.filter (fun x -> fst(x) = object.Id)
                    |> List.map (fun x -> snd(x))
                    |> List.map (fun x -> { Id = x; Orbits = Some object; OrbitedBy = List.empty })
                    |> List.map (fun x -> createObject2 x values)
    { object with OrbitedBy = orbitedBy }
    
let rec getTotalDepth (object: object) =
    let innerDepth = object.OrbitedBy |> List.sumBy getTotalDepth
    object.Depth + innerDepth
    
//let rec find (id: string) (root: object2) =
//    if id = root.Id then Some root
//    else if List.isEmpty root.OrbitedBy then None
//    else
//        List.map (fun x -> find id x) root.OrbitedBy |> List.head
//        let matching = root.OrbitedBy |> List.tryFind (fun x -> x.Id = id)
//        match matching with
//            | Some x -> Some x
//            | None -> 
    
let objects = inputLines |> List.ofSeq |> List.map (fun x -> x.Substring(0, 3), x.Substring(4,3))
        
let partOne =
    printfn "Day 6 part 1"
    let result = createObject (createObjectRaw "COM" 0) objects
    getTotalDepth result |> string

let partTwo =
    printfn "day 6 part 2"
//    let com = createObject2 { Id = "COM"; Orbits = None ; OrbitedBy = List.empty } objects
//    let you = find "YOU" com
//    match you with
//        | Some x -> x.Id

