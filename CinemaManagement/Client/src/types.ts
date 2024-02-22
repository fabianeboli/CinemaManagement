import type { ViteSSGContext } from 'vite-ssg'

export type UserModule = (ctx: ViteSSGContext) => void

export type Film = {
  id: number
  title: string
  description: string;
  genre: string,
  duration: number,
  image: string
}


export type FilmDetails = {

}

export type Showtime = {
  id: number;
  auditorium: {
    name: string;
    theaterId: number;
    seats: Seat[];
  }
  date: Date;
}

export type Seat = {
  id: number;
  row: number;
  column: number;
  ReservedAt: Date;
  ReservedBy: number;
}
