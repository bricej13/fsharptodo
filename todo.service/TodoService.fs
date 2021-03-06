module todo.service.TodoService

type todo =
    { id: int option
      description: string
      completed: bool }

let mutable data =
    [ for i in 0 .. 10 ->
          { description = ("task " + i.ToString())
            id = Some i
            completed = i % 3 = 0 } ]

// GETs
let getAll = data

let getActive = data |> List.filter (fun t -> not t.completed)

let get id = data |> List.tryFind (fun x -> x.id.Value = id)


// POSTs
let create (body : todo) = body 

// PUTs
let update id = $"Updating todo %d{id}"
let complete id = "Completing todo " + id.ToString()

// DELETEs
let delete id = data <- List.filter (fun x -> x.id.Value <> id) data
