// export type UserModule = (ctx: ViteSSGContext) => void

export type Film = {
  id: number
  title: string
  description: string;
  genre: string,
  duration: number,
  image: string
}


export type FilmDetails = {
  id: number
}

export type Showtime = {
  id: number;
  film: Film;
  auditorium: Auditorium;
  date: Date;
}

export type Auditorium = {
  id: number;
  name: string;
  theaterId: number;
  seats: TSeat[];
}

export type TSeat = {
  id: number;
  row: string;
  column: string;
  reservedAt: Date;
  reservedByUserId: number;
}