export class EventDto {
public AssignEvent(init: Partial<EventDto>){
  Object.assign(this, init);
}
constructor(){}
  public Id!: string | null;
  public Name!: string;
  public Description!: string;
  public Program!: string;
  public Location!: string;
  public TimeZone!: string;
  public StartDate!: Date;
  public EndDate!: Date;
}
