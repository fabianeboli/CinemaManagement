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


/**
 * Definition for singly-linked list.
 * class ListNode {
 *     val: number
 *     next: ListNode | null
 *     constructor(val?: number, next?: ListNode | null) {
 *         this.val = (val===undefined ? 0 : val)
 *         this.next = (next===undefined ? null : next)
 *     }
 * }
 */

function mergeTwoLists(list1: ListNode | null, list2: ListNode | null): ListNode | null {
  const head = new ListNode();
  let current = head

  while (list1 && list2) {
    if (list1.val < list2.val) {
      current.next = list1
      list1 = list1.next
    }
    else {
      current.next = list2
      list2 = list2.next
    }
    current = current.next
  }

  current.next = list1 ?? list2

  return head.next
}

function reverseList(head: ListNode | null): ListNode | null {
  let prev = null

  while (head) {
    const swp = head.next
    head.next = prev
    prev = head
    head = swp
  }

  return prev
};

function maxProfit(prices: number[]): number {
  let buy = 0
  let sell = 1
  let maxProfit = 0

  while (sell < prices.length) {
    if (prices[buy] < prices[sell]) {
      const profit = prices[sell] - prices[buy]
      maxProfit = Math.max(profit, maxProfit)
    } else {
      buy = sell
    }
    sell++
  }

  return maxProfit
}