module todo.webapi.todo_service

open FSharp.Json
open Suave
open Suave.Successful
open Suave.RequestErrors

let mutable data =
    [ for i in 0 .. 10 ->
          { description = ("task " + i.ToString())
            id = i
            completed = false } ]

// GETs
let getAll = data |> Json.serialize |> OK

let get id =
    data
    |> List.tryFind (fun x -> x.id = id)
    |> function
        | Some x -> x |> Json.serialize |> OK
        | None -> NOT_FOUND "todo item not found"
    

// POSTs
let create = OK "Creating todo"

// PUTs
let update id = OK("Updating todo " + id.ToString())
let complete id = OK("Completing todo " + id.ToString())

// DELETEs
let delete id =
    data <- List.filter (fun x -> x.id <> id) data
    NO_CONTENT
        
