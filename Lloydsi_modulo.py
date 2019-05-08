inp = 361542

input1 = list(map(int, str(inp)))

#reversed sorted list is the highest permutation
input1.sort(reverse=True)

x = list(map(str, input1))
x = "".join(x)

rang = int(x)
res = -1
for i in range(rang, 0, -1):
        m = map(int, str(i))
        m = list(m)
        m.sort(reverse=True)
        if m == input1:
                if i % 8 == 5:
                        res = i
                        break

print(res)





