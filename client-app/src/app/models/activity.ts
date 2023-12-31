
// Purpose: Interface for activity model
// An interface is a syntactical contract that an entity should conform to.

export interface Activity {
    id: string
    title: string
    date: Date | null
    description: string
    category: string
    city: string
    venue: string
  }