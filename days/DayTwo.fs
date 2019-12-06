module DayTwo

let rec updateIntcode (array: int[]) index =
    let newArray = Array.copy array
    let getOpFun i =
        let add x y = x + y
        let times x y = x * y
        let opcode = array.[i]
        match opcode with
                    | 1 -> Some add
                    | 2 -> Some times
                    | 99 -> None
    let i1 = index + 1
    let i2 = index + 2
    let update f = Array.set newArray newArray.[(index + 3)] (f array.[array.[i1]] array.[array.[i2]])
    match getOpFun index with
                        | Some f -> update f
                                    updateIntcode newArray (index + 4)
                        | None -> newArray
                       

let inputList =
    let readFile() = System.IO.File.ReadAllText "input/day2.txt"
    let split (text:string) = text.Split [|','|]
    readFile >> split >> Array.map int

let partOne() =
    printfn "day 2"
    let inputListResult = inputList()
    let newArray = updateIntcode inputListResult 0
    newArray.[0] |> string
    
type Input = { Noun: int; Verb: int }

let nextInput input =
    if input.Verb = 99 then
        { Noun = input.Noun; Verb = 0 }
    else
        { Noun = input.Noun + 1; Verb = input.Verb + 1 }
        


let changeInput input array =
    let clone = Array.copy array
    Array.set clone 1 input.Noun
    Array.set clone 2 input.Verb
    clone
    
let haltNumber = 19690720

let matchesHaltNumber input =
    let inputListResult = inputList() |> changeInput input
    let newArray = updateIntcode inputListResult 0
    newArray.[0] = haltNumber
    
let rec matchTillHalt input =
    match matchesHaltNumber input with
            | true -> input
            | false -> nextInput input |> matchTillHalt
            
let getMagicNumber input =
    100 * input.Noun + input.Verb

let initialInput = { Noun = 0; Verb = 0 }
    
let partTwo() =
    printfn "day 2 part 2"
    let matchingInput = matchTillHalt initialInput
    getMagicNumber matchingInput |> string