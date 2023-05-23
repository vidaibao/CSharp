def reverse(llist):
    result = None
    while llist:
        temp = llist.next
        llist.next = result
        llist.prev = temp
        result = llist
        llist = llist.prev
    return result