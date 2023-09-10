const getListask = () => {
  cy.request("GET", `${endPoint}Task/Get`)
}

describe('test service with mockup Get task', () => {
  it('Get task', () => {
    getListask()
    
    cy.contains("table").should("have.length", 1)
  })
})