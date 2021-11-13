const express = require('express')

const app = express()
const port = 8082

app.post('/payment/transfers', (req, res) => {
    res.send({
        success: true
    })
})

app.listen(port, () => {
    console.log(`Example app listening at http://localhost:${port}`)
})
